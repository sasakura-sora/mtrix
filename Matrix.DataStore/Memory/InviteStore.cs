using System.Collections.Generic;

namespace Matrix.DataStore.Memory
{
    public static class InviteStore
    {
        static InviteStore()
        {
            Invites = new Dictionary<string, List<string>>();
        }

        public static Dictionary<string, List<string>> Invites;
    }
}
