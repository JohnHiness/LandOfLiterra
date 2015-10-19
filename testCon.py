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