﻿namespace DispoHub.Shared.Utils
{
    public static class IDHelper
    {
        public const long INVALID_ID = -1;

        public static bool IsIdValid(this long id)
            => id > 0;

        public static bool IsIdValid(this long? id)
            => id != null || id > 0;

        public static bool IsIdInvalid(this long id)
            => id < 1;

        public static bool IsIdInvalid(this long? id)
            => id == null || id < 1;
    }
}