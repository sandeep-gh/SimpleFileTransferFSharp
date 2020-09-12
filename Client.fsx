open NetworkingCommon
open System
open System.IO


let mutable buffer : byte array  = getMutableBuffer pageSize
let connHandle = connectLocal 7153
let connStream = connHandle.GetStream()
let connStreamReader = readStreamPagesSeq 262144 connStream buffer
//file writer handle
let path = "clientTestfile.dat"
let fs = File.Create(path)

let fileStreamWriter = writeToStream fs

connStreamReader |> Seq.iter fileStreamWriter

//TODO: cleanup
