using Exiled.API.Features;
using MEC;

namespace JoinUnmute
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin plugin;
        public override string Prefix => "JoinUnmute";
        public override string Name => "JoinUnmute";
        public override string Author => "[OPENSOURCE PLUGIN] [https://github.com/scp-sl-opensource-plugins]";

        public override void OnEnabled()
        {
            plugin = this;
            Exiled.Events.Handlers.Player.Verified += Player_Verified;
            base.OnEnabled();
        }

        private void Player_Verified(Exiled.Events.EventArgs.Player.VerifiedEventArgs ev)
        {
            Timing.CallDelayed(1, () =>
            {
                if (ev.Player.IsMuted)
                {
                    ev.Player.UnMute();
                    Log.Debug($"{ev.Player} unmuted.");
                }
            });
        }

        public override void OnDisabled()
        {
            plugin = null;
            Exiled.Events.Handlers.Player.Verified -= Player_Verified;
            base.OnDisabled();
        }
    }
}