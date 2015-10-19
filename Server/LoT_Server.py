__author__ = 'John Hiness'
import socket
import thread
import time
import sys
import string
import os
import hashlib


dev = True

host = ''
port = 3202
maximumConnections = 128
currentConnections = 0
accountListFilename = "LoT_Accounts.lot"
# ss = socket.socket( socket.AF_INET, socket.SOCK_STREAM )

def printTime():
	while True:
		print time.time()
		time.sleep(5)


def cnsl(text):
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
	except socket.error , msg:
		cnsl('Bind failed. Error code: ' + str(msg[0]) + ' Message ' + msg[1])
		sys.exit()
	cnsl("Socket bind successful on port " + str(port))
	s.listen(10)


try:
	s = socket.socket( socket.AF_INET, socket.SOCK_STREAM )
except socket.error, msg:
	cnsl('Failed to create socket. Error code: ' + str(msg[0]) + ' , Error message : ' + msg[1])
	sys.exit()
cnsl("Socket created.")


def readAccountList():
	accListFile = open(accountListFilename, 'r').read()
	accList = []
	for line in accListFile.split("\n"):
		if line.find("#") != -1:
			lineToAdd = line[:line.find("#")]
		else:
			lineToAdd = line
		if not line.find("|") != -1:
			print "ERROR IN ACCOUNTFILE: Line not recognized format: " + line
			break
		if not lineToAdd == "":
			accList.append({"usr":line[:line.find("|")], "pwd":line[line.find("|")+1:]})
	return accList


def checkAuth(username, password, randomString, caseSens=False):
	acclist = readAccountList()
	for acc in acclist:
		if caseSens:
			if acc["usr"] == username:
				if hashlib.sha256(randomString + acc["pwd"]) == hashlib.sha256(randomString + password):
					return True
		else:
			if acc["usr"].lower() == username.lower():
				if hashlib.sha256(randomString + acc["pwd"]) == hashlib.sha256(randomString + password):
					return True
		break
	return False


def clientThread(client, name):
	def send(text):
		if dev:
			cnsl(" >> " + name + ' :' + text)
		client.send(text + '\n')

	def closeConnection():
		cnsl("Closing connection with " + name)
		client.close()

	randomAuth = os.urandom(20)
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
			evnt = rline[0, rline.find("|")]
			emesg = rline[rline.find("|")+1:]
			if dev:
				cnsl("<<  " + name + ' :' + ' '.join(rline))
			if not loggedIn:
				if evnt == "auth":
					attemptedUsr = emesg[0, emesg.find("|")]
					attemptedPwd = emesg[emesg.find("|")+1:]
					if not os.path.exists(accountListFilename):
						send("popup|We apoplogize. Something has gone terribly wrong with the server and you won't be able to log in right now. Try again later.")
						print "FATAL ERROR: LoT_Accounts.lot NOT FOUND! ALL AUTHORIZATIONS WILL BE AUTOMATICLY DENIED UNTIL FILE IS EXISTING!"
						cnsl("Attempted login with user \"" + attemptedUsr + "\" with client \"" + name + "\" denied.")
						closeConnection()
						break
					if checkAuth(attemptedUsr, attemptedPwd, randomAuth, False):
						loggedIn = True
						send("authRes|true")
						cnsl("User successfully logged in with usr/pwd/rng: " + attemptedUsr + "/" + attemptedPwd + "/" + randomAuth)
					else:
						loggedIn = False
						send("authRes|false")
				break
	closeConnection()


if __name__ == '__main__':
	startListen()
	#thread.start_new_thread(printTime, ())
	while True:
		conn, addr = s.accept()
		cnsl("Connected with " + addr[0] + ':' + str(addr[1]))
		clName = addr[0] + ':' + str(addr[1])
		thread.start_new_thread(clientThread, (conn, clName))
	s.close()