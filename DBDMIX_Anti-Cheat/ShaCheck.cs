using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;

public class ShaCheck
{
    public string GenerateSha1FromFile(string filepath, int blocksize)
    {
        FileStream fs = File.Open(filepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        SHA1 sha1 = new SHA1Managed();

        byte[] buffer = new byte[blocksize];

        int readbytes = 0;
        while (true)
        {
            Thread.Sleep(200);
            readbytes = fs.Read(buffer, 0, blocksize);

            if (readbytes == 0)
            {
                sha1.TransformFinalBlock(buffer, 0, 0);
                break;
            }
            if (readbytes <= blocksize)
                sha1.TransformBlock(buffer, 0, readbytes, buffer, 0);
        }

        fs.Close();
        fs.Dispose();

        string hash = BitConverter.ToString(sha1.Hash).Replace("-", "").ToLower();

        sha1.Dispose();

        Console.WriteLine("Sha1-Hash: {0}", hash);
        return hash;
    }
    public static void PrintHashMultiBlock(byte[] input, int size)
    {
        SHA1 sha = new SHA1Managed();
        int offset = 0;

        while (input.Length - offset >= size)
            offset += sha.TransformBlock(input, offset, size, input, offset);

        sha.TransformFinalBlock(input, offset, input.Length - offset);

        Console.WriteLine("MultiBlock {0:00}: {1}", size, BitConverter.ToString(sha.Hash).Replace("-", ""));
    }


    static int ReadBlock(Stream s, byte[] block)
    {
        int position = 0;
        while (position < block.Length)
        {
            var actuallyRead = s.Read(block, position, block.Length - position);
            if (actuallyRead == 0)
                break;
            position += actuallyRead;
        }
        return position;
    }
    //  Она читает блок данных из потока, и возвращает количество реально прочитанных байт.Все блоки, за исключением последнего, будут полными.

    // Теперь ваш код должен выглядеть как-то так:

    //using (var infile = File.OpenRead(inpath))
    //using (var outfile = File.Create(outpath))
    //{
    //    byte[] buf = new byte[64];
    //    while (true)
    //    {
    //        var bytesRead = ReadBlock(infile, buf);
    //        if (bytesRead == 0)
    //            break;
    //        // байты с номерами от 0 до bytesRead сложить с соответствующими байтами ключа
    //        // выравнивание до границы 64 байт не нужно
    //        outfile.Write(buf, 0, bytesRead);
    //    }
    //}
}