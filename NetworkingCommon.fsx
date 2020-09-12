module NetworkingCommon =

    open System.Net
    open System.Net.Sockets
    open System.IO

    let pageSize  = 4096

    //TODO: might be good idea to have buffer tagged with different states
    //to-be-read, reading, to-be-written, written

    //what if allocation fails
    let getMutableBuffer pageSize =
        let mutable buffer : byte array = Array.zeroCreate pageSize
        buffer

    //what if connection fails
    let connect host port =
        new TcpClient(host, port)

    let connectLocal port =
        connect "localhost" port

    //what if listener fails
    let listener (host : string)  port =
        let listenerHandle = new TcpListener(localaddr=IPAddress.Parse host, port = port)
        listenerHandle.Start()
        listenerHandle

    //what if socket waiting fails
    let waitForConnection (listenerHandle : TcpListener) =
        listenerHandle.Server.Accept()

    let getSocketStream (socket : Socket) =
        let socketStream = new NetworkStream(socket)
        socketStream


    //what if write fails
    let writeToStream (stream : Stream) (buffer : byte array) =
        stream.Write(buffer, 0, buffer.Length)


    //what if read fails or not able to read completely
    let readFromStream size (stream : Stream) buffer  =
        stream.Read(buffer, 0, size)

    //read numPages from stream
    let readStreamPagesSeq numPages (stream : Stream) buffer   =
        seq {
            for i in 1..numPages do
            readFromStream pageSize stream buffer |> ignore
            buffer
            }
