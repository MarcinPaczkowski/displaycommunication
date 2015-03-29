namespace DisplayCommon.Models
{
    public enum MessageType
    {
        J,  // wolne miejsca - cyfra 0-9
        D,  // wolne miejsca - liczba 10-99
        Jj, // wolne miejsca - cyfra 0-9,       zajęte miejsca - cyfra 0-9
        Jd, // wolne miejsca - cyfra 0-9,       zajęte miejsca - cyfra 10-99
        Dj, // wolne miejsca - liczba 10-99,    zajęte miejsca - cyfra 0-9
        Dd  // wolne miejsca - liczba 10-99,    zajęte miejsca - cyfra 10-99
    }
}
