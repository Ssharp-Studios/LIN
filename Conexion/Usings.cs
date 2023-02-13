
#if WINDOWS
global using MySql.Data.MySqlClient;
#elif ANDROID || IOS || MACCATALYST
global using MySqlConnector;
#endif

global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using System.IO;
global using System.Threading.Tasks;