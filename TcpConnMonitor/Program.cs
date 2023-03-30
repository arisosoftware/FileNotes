using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net;

namespace TcpConnMonitor
{
    internal class Program
    {
        class TcpConnRecord
        {
            public DateTime startTime;
            public string TCPConnPair;
            public DateTime endTime;
            public char Flag;
            public string TimeSpent()
            {
                return (endTime - startTime).ToString(@"mm\:ss");
            }
        }



        static void Main(string[] args)
        {
            Dictionary<string, TcpConnRecord> monitorLog = new Dictionary<string, TcpConnRecord>();
            List<string> previousNetstatOutput = new List<string>();
            while (true)
            {
                DateTime dateTime = DateTime.Now;

                List<string> currentNetstatOutput = GetNetstatOutput(".2.23:");



                if (previousNetstatOutput != null)
                {

                    var netstatDiff = GetNetstatDiff(previousNetstatOutput, currentNetstatOutput);

                    foreach (var diffrecord in netstatDiff)
                    {
                        bool needLog = false;
                        bool isNew = true;
                        var item = new TcpConnRecord()
                        {
                            TCPConnPair = diffrecord.TCPConnPair,
                            startTime = dateTime,
                        };

                        if (monitorLog.ContainsKey(diffrecord.TCPConnPair))
                        {
                            item = monitorLog[diffrecord.TCPConnPair];
                            isNew = false;
                        }
                        else
                        {
                            monitorLog.Add(diffrecord.TCPConnPair, item);
                        }

                        if (diffrecord.Flag == '>')
                        {
                            item.startTime = dateTime;
                            needLog = true;
                        }
                        else if (diffrecord.Flag == '<')
                        {
                            item.endTime = dateTime;
                            monitorLog.Remove(item.TCPConnPair);
                            needLog = true;
                        }
                        else if (diffrecord.Flag == '=')
                        {
                            if (isNew)
                            {
                                needLog = true;
                            }
                        }
                        string timeFmt = "MMdd.HH:mm:ss";
                        if (needLog)
                        {
                            if (diffrecord.Flag == '<')
                            {
                                Console.WriteLine("{0,-14} Del {1,-39} Elapsed {2,-5} Since {3,-9}",
                                    dateTime.ToString(timeFmt), item.TCPConnPair, item.TimeSpent(), item.startTime.ToString("HH:mm:ss"));
                            }
                            else
                            {
                                Console.WriteLine("{0,-14} New {1,-39}",
                                    dateTime.ToString(timeFmt), item.TCPConnPair);
                            }

                        }
                    }
                }
                previousNetstatOutput = currentNetstatOutput;
                System.Threading.Thread.Sleep(500);
            }
        }

        static List<string> GetNetstatOutput(string filter)
        {
            List<string> result = new List<string>();
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] connections = properties.GetActiveTcpConnections();

            foreach (TcpConnectionInformation connection in connections)
            {
                if (connection.LocalEndPoint.ToString().Contains(filter) && connection.State == TcpState.Established)
                {
                    result.Add($"{connection.LocalEndPoint} {connection.RemoteEndPoint}");
                }
            }
            return result;
        }

        static List<TcpConnRecord> GetNetstatDiff(List<string> previousNetstatOutput, List<string> currentNetstatOutput)
        {
            var added = currentNetstatOutput.Except(previousNetstatOutput);
            var deleted = previousNetstatOutput.Except(currentNetstatOutput);
            var unchanged = previousNetstatOutput.Intersect(currentNetstatOutput);

            List<TcpConnRecord> records = new List<TcpConnRecord>();

            foreach (string element in added)
            {
                records.Add(new TcpConnRecord()
                {
                    startTime = DateTime.Now,
                    TCPConnPair = element,
                    Flag = '>'
                });
            }

            foreach (string element in deleted)
            {
                records.Add(new TcpConnRecord()
                {
                    startTime = DateTime.Now,
                    TCPConnPair = element,
                    Flag = '<'
                });
            }

            foreach (string element in unchanged)
            {
                records.Add(new TcpConnRecord()
                {
                    startTime = DateTime.Now,
                    TCPConnPair = element,
                    Flag = '='
                });
            }

            return records;
        }
    }
}
//                            Console.WriteLine($"{dateTime.ToString(timeFmt)}|Del|{item.TCPConnPair}|Elapsed {item.TimeSpent()}|@{item.startTime.ToString(timeFmt)} ");