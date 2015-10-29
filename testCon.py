## THIS IS JUST A TMP FILE TO EASILY TRY OUT SOCKET ##

"""import socket
import string

s = socket.socket( socket.AF_INET, socket.SOCK_STREAM )

s.connect(("localhost", 3202))
read = ''
while True:
	readbuffer = readbuffer + s.recv(2048)
	temp = string.split(readbuffer, "\n")
	readbuffer = temp.pop()

	for rline in temp:
		rline = string.rstrip(rline)
		rline = string.split(rline)
		print rline"""

import socket   #for sockets
import sys  #for exit
import string
import time
import hashlib

try:
    #create an AF_INET, STREAM socket (TCP)
    s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
except socket.error, msg:
    print 'Failed to create socket. Error code: ' + str(msg[0]) + ' , Error message : ' + msg[1]
    sys.exit();

print 'Socket Created'

host = 'localhost'
port = 3202

try:
    remote_ip = socket.gethostbyname( host )

except socket.gaierror:
    #could not resolve
    print 'Hostname could not be resolved. Exiting'
    sys.exit()

print 'Ip address of ' + host + ' is ' + remote_ip

#Connect to remote server
s.connect((remote_ip , port))

print 'Socket Connected to ' + host + ' on ip ' + remote_ip
readbuffer = ''
while True:
	readbuffer = readbuffer + s.recv(2048)
	temp = string.split(readbuffer, "\n")
	readbuffer = temp.pop()
	time.sleep(1)
	s.send("I'm here! 1\n")
	time.sleep(2)
	s.send("Still here! 2\n")

	for rline in temp:
		rline = string.rstrip(rline)
		rline = string.split(rline)
		print "Recv: " + ' '.join(rline)
		line = ' '.join(rline)
		evnt = line[:line.find("|")]
		msg = line[line.find("|")+1:]
		if evnt == "auth":
			print "-Auth request-"
			username = raw_input("Username: ")
			password = raw_input("Password: ")
			rstring = msg.split("|")
			print "rstring="+str(rstring)
			print "password="+password
			print "passhash="+hashlib.sha256(password).hexdigest()
			s.send("auth|" + username+"|"+hashlib.sha256(msg+hashlib.sha256(password).hexdigest()).hexdigest() + "\n")
		if evnt == "authRes":
			if msg == "true":
				print "Successfully logged in."
			elif msg == "false":
				print "Login failed."
			else:
				print "Unknown error: " + msg
