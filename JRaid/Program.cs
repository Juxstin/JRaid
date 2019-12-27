using Discord;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRaid
{
    class Program
    {

        static void Print(string str)
        {
            Console.WriteLine(str);
        }
        static void Clear()
        {
            Console.Clear();
        }
        private static Random random = new Random();
        static string ReadLine()
        {
            return Console.ReadLine();
        }
        static void Main(string[] args)
        {
            Console.Title = "JRaid | Version - ALPHA 0.1";
            WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
            wplayer.URL = AppDomain.CurrentDomain.BaseDirectory + "\\lund.mp3";
            wplayer.controls.play();
            Console.OutputEncoding = Encoding.ASCII;
            Print("Type help for help");
            while (true)
            {
                string[] userArgs = ReadLine().Split(' ');
                //join [guildid] [delayinms]
                if (userArgs[0] == "join")
                {
                    if (userArgs[1] != null && userArgs[2] != null) { } else { Print("Missing Params"); return; }
                    foreach (string line in File.ReadAllLines("Tokens.txt"))
                    {
                        var rt = Task.Run(async delegate
                        {

                            DiscordClient client = new DiscordClient(line);

                            GuildInvite invite = client.JoinGuild(userArgs[1]);

                            await Task.Delay(Int32.Parse(userArgs[2]));
                        });
                    }
                }
                //joingroup [guildid] [delayinms]
                if (userArgs[0] == "joingroup")
                {
                    if (userArgs[1] != null && userArgs[2] != null) { } else { Print("Missing Params"); return; }
                    foreach (string line in File.ReadAllLines("Tokens.txt"))
                    {
                        var rt = Task.Run(async delegate
                        {

                            DiscordClient client = new DiscordClient(line);

                            GuildInvite invite = client.JoinGuild(userArgs[1]);

                            await Task.Delay(Int32.Parse(userArgs[2]));
                        });
                    }
                }
                //leave [guildid] [delayinms]
                if (userArgs[0] == "leave")
                {
                    if (userArgs[1] != null && userArgs[2] != null) { } else { Print("Missing Params"); return; }
                    foreach (string line in File.ReadAllLines("Tokens.txt"))
                    {
                        var rt = Task.Run(async delegate
                        {

                            DiscordClient client = new DiscordClient(line);

                            client.LeaveGuild(ulong.Parse(userArgs[1]));

                            await Task.Delay(Int32.Parse(userArgs[2]));
                        });
                    }
                }
                //leavegroup [groupid] [delayinms]
                if (userArgs[0] == "leavegroup")
                {
                    if (userArgs[1] != null && userArgs[2] != null) { } else { Print("Missing Params"); return; }
                    foreach (string line in File.ReadAllLines("Tokens.txt"))
                    {
                        var rt = Task.Run(async delegate
                        {

                            DiscordClient client = new DiscordClient(line);

                            client.LeaveGroup(ulong.Parse(userArgs[1]));

                            await Task.Delay(Int32.Parse(userArgs[2]));
                        });
                    }
                }
                //say [channelid] [delayinms] [y/n trigger typing] [message no spaces]
                if (userArgs[0] == "say")
                {
                    if (userArgs[1] != null && userArgs[2] != null && userArgs[3] != null && userArgs[4] != null) { } else { Print("Missing Params"); return; }
                    foreach (string line in File.ReadAllLines("Tokens.txt"))
                    {
                        var rt = Task.Run(async delegate
                        {

                            DiscordClient client = new DiscordClient(line);

                            TextChannel channel = client.GetChannel(ulong.Parse(userArgs[1])).ToTextChannel();
                            if (userArgs[3] == "y")
                            {
                                channel.TriggerTyping();
                                channel.SendMessage(userArgs[4]);
                                await Task.Delay(Int32.Parse(userArgs[2]));
                            }
                            else
                            {
                                channel.SendMessage(userArgs[4]);
                                await Task.Delay(Int32.Parse(userArgs[2]));
                            }
                        });
                    }
                }
                //saydm [channelid] [delayinms] [y/n trigger typing] [message no spaces]
                if (userArgs[0] == "saydm")
                {
                    if (userArgs[1] != null && userArgs[2] != null && userArgs[3] != null && userArgs[4] != null) { } else { Print("Missing Params"); return; }
                    foreach (string line in File.ReadAllLines("Tokens.txt"))
                    {
                        var rt = Task.Run(async delegate
                        {
                            DiscordClient client = new DiscordClient(line);

                            DMChannel channel = client.GetDMChannel(ulong.Parse(userArgs[1]));
                            if (userArgs[3] == "y")
                            {
                                channel.TriggerTyping();
                                channel.SendMessage(userArgs[4]);
                                await Task.Delay(Int32.Parse(userArgs[2]));
                            }
                            else
                            {
                                channel.SendMessage(userArgs[4]);
                                await Task.Delay(Int32.Parse(userArgs[2]));
                            }
                        });
                    }
                }
                //saygroup [channelid] [delayinms] [y/n trigger typing] [message no spaces]
                if (userArgs[0] == "saygroup")
                {
                    if (userArgs[1] != null && userArgs[2] != null && userArgs[3] != null && userArgs[4] != null) { } else { Print("Missing Params"); return; }
                    foreach (string line in File.ReadAllLines("Tokens.txt"))
                    {
                        var rt = Task.Run(async delegate
                        {
                            DiscordClient client = new DiscordClient(line);

                            DMChannel channel = client.GetGroup(ulong.Parse(userArgs[1]));
                            if (userArgs[3] == "y")
                            {
                                channel.TriggerTyping();
                                channel.SendMessage(userArgs[4]);
                                await Task.Delay(Int32.Parse(userArgs[2]));
                            }
                            else
                            {
                                channel.SendMessage(userArgs[4]);
                                await Task.Delay(Int32.Parse(userArgs[2]));
                            }
                        });
                    }
                }
                //friend [userid] [delayinms]
                if (userArgs[0] == "friend")
                {
                    if (userArgs[1] != null && userArgs[2] != null) { } else { Print("Missing Params"); return; }
                    foreach (string line in File.ReadAllLines("Tokens.txt"))
                    {
                        var rt = Task.Run(async delegate
                        {
                            DiscordClient client = new DiscordClient(line);

                            client.SendFriendRequest2(ulong.Parse(userArgs[1]));

                            await Task.Delay(Int32.Parse(userArgs[2]));
                        });
                    }
                }
                //createinvite [channelid] [delayinms]
                if (userArgs[0] == "createinvite")
                {
                    if (userArgs[1] != null && userArgs[2] != null) { } else { Print("Missing Params"); return; }
                    foreach (string line in File.ReadAllLines("Tokens.txt"))
                    {
                        var rt = Task.Run(async delegate
                        {
                            DiscordClient client = new DiscordClient(line);

                            client.CreateInvite(ulong.Parse(userArgs[1]));

                            await Task.Delay(Int32.Parse(userArgs[2]));
                        });
                    }
                }
                if (userArgs[0] == "stopmusic")
                {
                        wplayer.controls.stop();
                }
                if (userArgs[0] == "playmusic")
                {
                        wplayer.controls.play();
                }
                if (userArgs[0] == "clr")
                {
                    Clear();
                }
                if (userArgs[0] == "help")
                {
                    Print("             ");
                    Print("join [guildid] [delayinms]");
                    Print("joingroup [guildid] [delayinms]");
                    Print("leave [guildid] [delayinms]");
                    Print("leavegroup [groupid] [delayinms]");
                    Print("friend [userid] [delayinms]");
                    Print("createinvite [channelid] [delayinms]");
                    Print("say [channelid] [delayinms] [y/n trigger typing] [message no spaces]");
                    Print("saydm [channelid] [delayinms] [y/n trigger typing] [message no spaces]");
                    Print("saygroup [channelid] [delayinms] [y/n trigger typing] [message no spaces]");
                    Print("clr -- Clears Console");
                    Print("stopmusic -- Stops music");
                    Print("playmusic -- Replays/Unpauses music");
                    Print("             ");
                }
            }
        }
    }
}
