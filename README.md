# SimpleFileTransferFSharp

A simple rudimentary but working file transfer code in F#. Server reads a file and sends (in batches of 4096 bytes) to client which writes the file to the disk. No error handling is done here. 