namespace DisplayExtensions.Enums
{
    public enum Command
    {
        Zero = 0xFF,
        StartText = 0xFE,
        EndText = 0xFD,
        SynchronizeTime = 0xFC,
        CloackDisplayTime = 0xFB,
        ResetToDefaultSettings = 0xFA,
        TimeToResetToDefaultText = 0xF8,
        DefaultText = 0xF7
    }
}
