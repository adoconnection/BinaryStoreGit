﻿namespace BinaryStore.Serializers;

public class BinaryStoreByteSerializer : IBinaryStoreSerializer
{
    public int Length
    {
        get
        {
            return 1;
        }
    }

    public bool RequiresLengthAttribute
    {
        get
        {
            return false;
        }
    }

    public Type Type
    {
        get
        {
            return typeof(byte);
        }
    }

    public void Serialize(Stream stream, object value, long lengthLimit)
    {
        stream.Write(new[] { (byte)value });
    }

    public object Deserialize(Stream stream, long lengthLimit)
    {
        byte[] buffer = new byte[this.Length];
        stream.Read(buffer, 0, this.Length);

        return buffer[0];
    }
}