using System.Net;

namespace FollowMeFree.API.Middleware;

public class IpWhitelistOptions
{
    public IPNetwork? AllowedNetwork { get; private set; }

    public void SetNetwork(string cidr)
    {
        var parts = cidr.Split('/');
        var address = IPAddress.Parse(parts[0]);
        var prefixLength = int.Parse(parts[1]);
        AllowedNetwork = new IPNetwork(address, prefixLength);
    }
}
