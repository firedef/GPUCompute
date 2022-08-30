namespace GPUCompute.utils; 

public static class ByteArrayUtils {
    public static byte ReadU8(this byte[] arr, ref int pos) => arr[pos++];
    public static sbyte ReadI8(this byte[] arr, ref int pos) => (sbyte)arr.ReadU8(ref pos);

    public static ushort ReadU16(this byte[] arr, ref int pos) => (ushort)((arr.ReadU8(ref pos) << 8) | arr.ReadU8(ref pos));
    public static short ReadI16(this byte[] arr, ref int pos) => (short)arr.ReadU16(ref pos);
    
    public static uint ReadU32(this byte[] arr, ref int pos) => ((uint)arr.ReadU16(ref pos) << 16) | arr.ReadU16(ref pos);
    public static int ReadI32(this byte[] arr, ref int pos) => (int)arr.ReadU32(ref pos);
    
    public static ulong ReadU64(this byte[] arr, ref int pos) => ((ulong)arr.ReadU32(ref pos) << 32) | arr.ReadU32(ref pos);
    public static long ReadI64(this byte[] arr, ref int pos) => (long)arr.ReadU64(ref pos);

    public static unsafe float ReadF32(this byte[] arr, ref int pos) {
        uint v = arr.ReadU32(ref pos);
        return *(float*)&v;
    }
    
    public static unsafe double ReadF64(this byte[] arr, ref int pos) {
        ulong v = arr.ReadU64(ref pos);
        return *(double*)&v;
    }

    public static unsafe T As<T, U>(this U v) where T : unmanaged where U : unmanaged => *(T*)&v;
}