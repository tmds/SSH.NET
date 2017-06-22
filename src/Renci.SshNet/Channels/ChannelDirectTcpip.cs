﻿using System.Net;
using System.Net.Sockets;
using Renci.SshNet.Messages.Connection;

namespace Renci.SshNet.Channels
{
    /// <summary>
    /// Implements "direct-tcpip" SSH channel.
    /// </summary>
    internal class ChannelDirectTcpip : ChannelDirectBase, IChannelDirectTcpip
    {
        /// <summary>
        /// Initializes a new <see cref="ChannelDirectTcpip"/> instance.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="localChannelNumber">The local channel number.</param>
        /// <param name="localWindowSize">Size of the window.</param>
        /// <param name="localPacketSize">Size of the packet.</param>
        public ChannelDirectTcpip(ISession session, uint localChannelNumber, uint localWindowSize, uint localPacketSize)
            : base(session, localChannelNumber, localWindowSize, localPacketSize)
        {
        }

        /// <summary>
        /// Gets the type of the channel.
        /// </summary>
        /// <value>
        /// The type of the channel.
        /// </value>
        public override ChannelTypes ChannelType
        {
            get { return ChannelTypes.DirectTcpip; }
        }

        public void Open(string remoteHost, uint port, IForwardedPort forwardedPort, Socket socket)
        {
            var ep = (IPEndPoint) socket.RemoteEndPoint;
            base.Open(new DirectTcpipChannelInfo(remoteHost, port, ep.Address.ToString(), (uint) ep.Port), forwardedPort, socket);
        }
    }
}
