namespace NodusOperandi.Data.Models
{

    /// <summary>
    /// Stores information about a NodusOperandi entity.
    /// </summary>
    public class Network : AbstractModel
    {

        public enum NetworkType
        {
            Wired,
            Wireless,
            VPN
        }

        public enum SecurityLevel
        {
            Open,
            WEP,
            WPA,
            WPA2Personal,
            WPA2Enterprise
        }

        /// <summary>
        /// Gets or sets the name / SSID of the network
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the network's IP address and subnet
        /// </summary>
        public string IpSubnet { get; set; }

        /// <summary>
        /// Gets or sets whether the network is DHCP-enabled
        /// </summary>
        public bool HasDhcp { get; set; }

        /// <summary>
        /// Gets or sets the DHCP start address
        /// </summary>
        public string DhcpStartAddress { get; set; }

        /// <summary>
        /// Gets or sets the DHCP end address
        /// </summary>
        public string DhcpEndAddress { get; set; }

        /// <summary>
        /// Gets or sets the network type
        /// </summary>
        public NetworkType Type { get; set; }

        /// <summary>
        /// Gets or sets the WiFi security level of the network
        /// </summary>
        public SecurityLevel WiFiSecurityLevel { get; set; }

        /// <summary>
        /// Gets or sets the WiFi password
        /// </summary>
        public string WiFiPassword { get; set; }

        /// <summary>
        /// Gets or sets whether the network has a guest portal for guest clients
        /// </summary>
        public bool HasGuestPortal { get; set; }

        /// <summary>
        /// Gets or sets the address of the guest portal
        /// </summary>
        public string GuestPortalAddress { get; set; }

    }

}
