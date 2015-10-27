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

clients = set()
clients_lock = threading.Lock()


class Log(object):
	def __init__(self):
		self.io = "## START OF I/O LOG %s ##" % time.time()
		self.auth = "## START OF AUTH LOG %s ##" % time.time()
		self.main = "## START OF MAIN LOG %s ##" % time.time()

	def io(self, text):
		self.io += '[' + time.strftime('%H:%M:%S') + '] ' + text

	def auth(self, text):
		self.auth += '[' + time.strftime('%H:%M:%S') + '] ' + text

	def main(self, text):
		self.main += '[' + time.strftime('%H:%M:%S') + '] ' + text

	def saveAll(self):
		return


def printTime():
	while True:
		print time.time()
		time.sleep(5)


def cnsl(text):
	Log.main(text)
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


class IOHandler(object):
	actionsToBeDone = []
	actionIDs = []
	files = {}

	def __init__(self):
		self.files = {'map': mapFilename,
					  'userInfo': userInfoFilename,
				  	  'accounts': accountListFilename}
		self.actionsToBeDone = []
		self.actionIDs = []

	def append(self, io_file, io_object):
		actionID = random.randint(0, 1000)
		while actionID in self.actionIDs:
			actionID = random.randint(0, 1000)
		self.actionIDs.append(actionID)
		self.actionsToBeDone.append({'id': actionID,
									 'file': io_file.lower(),
									 'object': io_object})
		return True

	def read(self, io_file, line=False):
		return



def getUserInformation(user, writeOver=False):
	userInfoFile = open(userInfoFilename, 'r').read()
	userList = ast.literal_eval(userInfoFile)
	if not userList[user.lower()]:
		return False
	if users[user] and not writeOver:
		return False
	users[user] = userList[user.lower()]


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


def clientThread(client, name):
	with clients_lock:
		clients.add(client)

	def send(text):
		if dev:
			cnsl(" >> " + name + ' :' + text)
		client.send(text + '\n')

	def closeConnection():
		cnsl("Closing connection with " + name)
		client.close()

	def outp(text):
		send("outMain|" + text)

	randomAuth = str(random.random())
	send("auth|" + randomAuth)
	loggedIn = False
	readbuffer = ''

	while True:
		try:
			readbuffer = readbuffer + client.recv(2048)
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
						closeConnection()
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

	closeConnection()

log = Log()
IOHandler = IOHandler()
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
		thread.start_new_thread(clientThread, (conn, clName))
	s.close()