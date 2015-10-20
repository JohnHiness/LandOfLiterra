__author__ = 'John Hiness'
import socket
import thread
import time
import sys
import string
import os
import hashlib
import random


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
	print accListFile
	count = 0
	for line in accListFile.split("\n"):
		count=count+1
		print "--"+str(count)+"--"
		print "++"+line
		if line.find("#") != -1:
			lineToAdd = line[:line.find("#")]
		else:
			lineToAdd = line
		print lineToAdd
		if not lineToAdd.find("|") != -1 and lineToAdd:
			print "ERROR IN ACCOUNTFILE: Line not recognized format: " + line
			break
		if not lineToAdd == "":
			list = lineToAdd.split("|")
			print "lta: \"" + list[0]+"\""
			print "pwd: \"" + list[1]+"\""
			accList.append({"usr":list[0].strip(), "pwd":list[1].strip()})
		print accList
	return accList


def checkAuth(username, password, randomString, caseSens=False):
	print "Attempted usr: '" + username +"'"
	print "Attempted pwd: '" + password + "'"
	print "Randomstring="+randomString
	acclist = readAccountList()
	for acc in acclist:
		print "Username: '" + acc["usr"] + "'"
		print "Password: '" + acc["pwd"] + "'"
		if caseSens:
			print "Testing '" + username + "' against '" + acc["usr"]
			if acc["usr"] == username:
				print "Testing '" + password + "' against '" + hashlib.sha256(randomString + acc["pwd"]).hexdigest() + "'"
				if hashlib.sha256(randomString + acc["pwd"]).hexdigest() == password:
					return True
		else:
			print "Testing '" + username.lower() + "' against '" + acc["usr"].lower()
			if acc["usr"].lower() == username.lower():
				print "Testing '" + password + "' against '" + hashlib.sha256(randomString + acc["pwd"]).hexdigest() + "'"
				if hashlib.sha256(randomString + acc["pwd"]).hexdigest() == password:
					return True

	return False


def clientThread(client, name):
	def send(text):
		if dev:
			cnsl(" >> " + name + ' :' + text)
		client.send(text + '\n')

	def closeConnection():
		cnsl("Closing connection with " + name)
		client.close()

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
			emesg = line[line.find("|")+1:]
			if dev:
				cnsl("<<  " + name + ' :' + line)
			if not loggedIn:
				if evnt == "auth":
					print "emesg: =" + emesg
					attemptedUsr = emesg[:emesg.find("|")]
					attemptedPwd = emesg[emesg.find("|")+1:]
					print attemptedUsr
					print attemptedPwd
					if not os.path.exists(accountListFilename):
						send("popup|We apoplogize. Something has gone terribly wrong with the server and you won't be able to log in right now. Try again later.")
						print "FATAL ERROR: \"" + accountListFilename + "\"-file NOT FOUND! ALL AUTHORIZATIONS WILL BE AUTOMATICLY DENIED UNTIL FILE IS EXISTING!"
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