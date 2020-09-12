open NetworkingCommon
open System
open System.IO

let mutable readBuffer : byte array = getMutableBuffer pageSize

let listenerHandle =  listener "127.0.0.1" 7153
let connectionStream = listenerHandle |> waitForConnection |> getSocketStream
let connectionStreamWriter = writeToStream connectionStream

let path = "testfile.dat"
let fileStream = File.OpenRead(path)
let fileStreamReader = readStreamPagesSeq  262144 fileStream readBuffer

fileStreamReader  |> Seq.iter  connectionStreamWriter

//TODO: Cleanup
