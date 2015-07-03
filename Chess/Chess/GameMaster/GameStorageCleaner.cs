using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Web;

namespace Chess.GameMaster
{
	public class GameStorageCleaner : IDisposable
	{
		private readonly Dictionary<Players, Game> storage;
		private Thread workThread;

		public GameStorageCleaner(Dictionary<Players, Game> gameStorage)
		{
			storage = gameStorage;
		}

		public void Start()
		{
			workThread = new Thread(StartClean);
		}


		private const int sleepTime = 50;
		/// <summary>
		/// minutes
		/// </summary>
		private const int storageTime = 10;

		private void StartClean()
		{
			while (true)
			{
				List<Players> keys;
				lock (storage)
				{
					keys = storage.Keys.ToList();
				}
				foreach (var p in keys.Where(p => DateTime.Now.Subtract(p.LastStepTime).Minutes > storageTime))
				{
					lock (storage)
					{
						if (!storage.ContainsKey(p))
							continue;
						RemoveAndSaveGame(p);
					}
					Thread.Sleep(sleepTime);
				}
			}
		}

		private void RemoveAndSaveGame(Players players)
		{
			return;
		}


		public void Dispose()
		{
			workThread.Interrupt();
		}
	}
}