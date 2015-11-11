import socket
import thread
import time
import sys
import string
import os
import hashlib
import random
import ast
import signal
import threading

__author__ = 'John Hiness'

dev = True

host = ''
port = 3202
maximumConnections = 128
currentConnections = 0
accountListFilename = "LoT_Accounts.lot"
userInfoFilename = "LoT_UserInfo.lot"
mapFilename = "LoT_DefaultMap.mlot"
users = {}
clientInstances = {}

clients = set()
clients_lock = threading.Lock()


class Log(object):
	def __init__(self):
		self.io_log = "## START OF I/O LOG %s ##" % time.time()
		self.auth_log = "## START OF AUTH LOG %s ##" % time.time()
		self.main_log = "## START OF MAIN LOG %s ##" % time.time()

	def io(self, text):
		self.io_log += '[' + time.strftime('%H:%M:%S') + '] ' + text

	def auth(self, text):
		self.auth_log += '[' + time.strftime('%H:%M:%S') + '] ' + text

	def main(self, text):
		self.main_log += '[' + time.strftime('%H:%M:%S') + '] ' + text

	def saveAll(self):
		return


class IOHandler(object):
	def __init__(self):
		self.files = {'map': mapFilename,
					  'userInfo': userInfoFilename,
				  	  'accounts': accountListFilename}
		self.actions = {}
		self.actionIDs = []
		thread.start_new_thread(self.worker, ())

	def worker(self):
		while True:
			try:
				if not self.actionIDs and not self.actions:
					break
				action = self.actions[self.actionIDs.pop(0)]
				if action['file'] not in self.files:
					print "ERROR IN I/O: File '%s' not found." % action['file']
					return False
				case = action['case']
				if case == 'read':
					file = open(action['file'], 'r').readlines()
					if action['line']:
						return file[action['line']]
					else:
						return '\n'.join(file)
				elif case == 'append':
					with open(action['file'], 'a') as file:
						file.write(action['text'])
						file.close()
				elif case == 'removel':
					file = open(action['file'], 'r').readlines()
					return file[action['line']]
				else:
					print 'ERROR IN I/O: Case "%s" not recognized.' % case
			except BaseException as exc:
				print 'ERROR IN I/O: ' + str(exc)

	def workHandler(self, action):
		actionID = random.randint(0, 1000)
		while actionID in self.actionIDs:
			actionID = random.randint(0, 1000)
		self.actionIDs.append(actionID)
		self.actions[actionID] = action
		while not self.actions[actionID]['done']:
			break
		results = self.actions[actionID]['returned']
		del self.actions[actionID]
		return results

	def append(self, io_file, io_object):
		return self.workHandler({'done': False,
								 'file': io_file.lower(),
								 'case': 'append',
								 'text': io_object})

	def read(self, io_file, line=False):
		return self.workHandler({'done': False,
								 'file': io_file.lower(),
								 'case': 'read',
								 'line': line})

	def removel(self, io_file, line):
		return self.workHandler({'done': False,
								 'file': io_file.lower(),
								 'case': 'removel',
								 'line': line})


class Player(object):
	def __init__(self, username):
		if not getUserInformation(username.lower()):
			inv = []
			hp = 0
			xp = 0
			pos = [0, 0]
			event = 0
			eventsDone = []
			equped = []
		else:
			inv, hp, xp, pos, event, eventsDone, equiped = getUserInformation(username)


class MapLoader(object):
	def __init__(self):
		self.readMap()
		self.graphMap()
		self.loadEnd()

	def graphMap(self):
		if not self.file_map:
			return False
		rawMap = self.file_map

	def loadEnd(self):


	def readMap(self):
		file = ioHandler.read('map')
		if not ('<lot>' in file.lower() and '</lot>' in file.lower() and
				'<map>' in file.lower() and '</map>' in file.lower() and
				'<map>' in file.lower() and '</map>' in file.lower()):
			cnsl('CRITICAL ERROR: MAP-FORMAT NOT RECOGNIZED.')
			cnsl('Make sure the right file is selected.')
			RuntimeError('ERROR MAP NOT RECOGNIZED')
			sys.exit(1)
		nfile = []
		for line in file.split('\n'):
			if '#' in line:
				line = line[:line.find('#')]
			nfile.append(line)
		file = '\n'.join(nfile)
		self.file_lot = file[file.lower().find('<lot>') + 5: file.lower().find('</lot>')]
		self.file_map = self.file_lot[file.lower().find('<map>') + 5: file.lower().find('</map>')]
		self.file_ent = self.file_lot[file.lower().find('<entities>') + 10: file.lower().find('</entities>')]
		if not self.file_map:
			cnsl("CRITICAL ERROR: MAP NOT FOUND.")
			RuntimeError('ERROR MAP NOT FOUND')
		if not self.file_ent:
			cnsl("CRITICAL ERROR: ENTITIES NOT FOUND.")
			RuntimeError('ERROR ENTITIES NOT FOUND')
		if not self.file_lot:
			cnsl("CRITICAL ERROR: MAPFILE NOT RECOGNIZED.")
			RuntimeError('ERROR MAPFILE NOT RECOGNIZED')
		if not (self.file_lot or self.file_map or self.file_ent):
			sys.exit(1)


class Client(object):
	def __init__(self, client, name):
		thread.start_new_thread(self.clientThread, ())
		self.client = client
		self.name = name

	def send(self, text):
		if dev:
			cnsl(" >> " + self.name + ' :' + text)
		self.client.send(text + '\n')

	def closeConnection(self):
			cnsl("Closing connection with " + self.name)
			self.client.close()

	def outp(self, text):
				self.send("outMain|" + text)

	def clientThread(self):
		name = self.name
		send = self.send
		outp = self.outp
		with clients_lock:
			clients.add(self.client)

		randomAuth = str(random.random())
		send("auth|" + randomAuth)
		loggedIn = False
		readbuffer = ''

		while True:
			try:
				readbuffer = readbuffer + self.client.recv(2048)
			except BaseException as err:
				cnsl("Error recieving from " + name + ' : ' + str(err))
				break
			temp = string.split(readbuffer, "\n")
			readbuffer = temp.pop()
			for rline in temp:
				rline = string.rstrip(rline)
				rline = string.split(rline)
				line = ' '.join(rline)
				evnt = line[:line.find("|")]
				emesg = line[line.find("|") + 1:]
				if dev:
					cnsl("<<  " + name + ' :' + line)
				if not loggedIn:
					if evnt == "auth":
						attemptedUsr = emesg[:emesg.find("|")]
						attemptedPwd = emesg[emesg.find("|") + 1:]
						if not os.path.exists(accountListFilename):
							send(
								"popup|We apoplogize. Something has gone terribly wrong with the server and you won't be able to log in right now. Try again later.")
							print "FATAL ERROR: \"" + accountListFilename + "\"-file NOT FOUND! ALL AUTHORIZATIONS WILL BE AUTOMATICLY DENIED UNTIL FILE IS EXISTING!"
							cnsl("Attempted login with user \"" + attemptedUsr + "\" with client \"" + name + "\" denied.")
							self.closeConnection()
							break
						if checkAuth(attemptedUsr, attemptedPwd, randomAuth, False):
							loggedIn = True
							send("authRes|true")
							cnsl(
								"User successfully logged in with usr/pwd/rng: " + attemptedUsr + "/" + attemptedPwd + "/" + randomAuth)
						else:
							loggedIn = False
							send("authRes|false")
					break
				outp("Welcome to the land of Literra!")


log = Log()
ioHandler = IOHandler()


def printTime():
	while True:
		print time.time()
		time.sleep(5)


def cnsl(text):
	log.main(text)
	print '[' + time.strftime('%H:%M:%S') + '] ' + text


def startListen():
	"""
	try:
		s = socket.socket( socket.AF_INET, socket.SOCK_STREAM )
	except socket.error, msg:
		cnsl('Failed to create socket. Error code: ' + str(msg[0]) + ' , Error message : ' + msg[1])
		sys.exit()
	cnsl("Socket created.") """
	try:
		s.bind((host, port))
	except socket.error, msg:
		cnsl('Bind failed. Error code: ' + str(msg[0]) + ' Message ' + msg[1])
		sys.exit()
	cnsl("Socket bind successful on port " + str(port))
	s.listen(10)


try:
	s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
except socket.error, msg:
	cnsl('Failed to create socket. Error code: ' + str(msg[0]) + ' , Error message : ' + msg[1])
	sys.exit()
cnsl("Socket created.")


def readAccountList():
	accListFile = open(accountListFilename, 'r').read()
	accList = []
	count = 0
	for line in accListFile.split("\n"):
		count = count + 1
		if line.find("#") != -1:
			lineToAdd = line[:line.find("#")]
		else:
			lineToAdd = line
		if not lineToAdd.find("|") != -1 and lineToAdd:
			print "ERROR IN ACCOUNTFILE: Line not recognized format: " + line
			break
		if not lineToAdd == "":
			list = lineToAdd.split("|")
			accList.append({"usr": list[0].strip(), "pwd": list[1].strip()})
	return accList


def checkAuth(username, password, randomString, caseSens=False):
	acclist = readAccountList()
	for acc in acclist:
		if caseSens:
			if acc["usr"] == username:
				if hashlib.sha256(randomString + acc["pwd"]).hexdigest() == password:
					return True
		else:
			if acc["usr"].lower() == username.lower():
				if hashlib.sha256(randomString + acc["pwd"]).hexdigest() == password:
					return True
	return False


def getUserInformation(user, writeOver=False):
	userInfoFile = open(userInfoFilename, 'r').read()
	userList = ast.literal_eval(userInfoFile)
	if not userList[user.lower()]:
		return False
	if users[user] and not writeOver:
		return False
	users[user] = userList[user.lower()]


if __name__ == '__main__':
	def signal_handler(signal, frame):
		print '-=STOPPING SERVER=-'
		s.close()
		sys.exit(0)

	startListen()
	signal.signal(signal.SIGINT, signal_handler)
	# thread.start_new_thread(printTime, ())
	while True:
		conn, addr = s.accept()
		cnsl("Connected with " + addr[0] + ':' + str(addr[1]))
		clName = addr[0] + ':' + str(addr[1])
		clientInstances[clName] = Client(conn, clName)
	s.close()