namespace FollowMeFree_Shared
{
    public class IpcResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string JsonPayload { get; set; }  // Serialized job list, status, etc.
    }
}
