using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VaultSharp;
using VaultSharp.V1.AuthMethods;
using VaultSharp.V1.AuthMethods.Token;

namespace InventoryService.VaultConfiguration
{
    public class VaultConnection
    {

        public async Task<Dictionary<string, object>> GetDBCredentials()
        {
            // Initialize one of the several auth methods.
            IAuthMethodInfo authMethod = new TokenAuthMethodInfo("s.dbWzzWKH2SxumihXafpopkCp");

            // Initialize settings. You can also set proxies, custom delegates etc. here.
            var vaultClientSettings = new VaultClientSettings("http://localhost:8200", authMethod);

            IVaultClient vaultClient = new VaultClient(vaultClientSettings);
            Console.WriteLine(vaultClient.V1.Secrets);
            //var dbcapability = await vaultClient.V1.System.GetCallingTokenCapabilitiesAsync("secret/jwt-secret");

            //var test = dbcapability.Data.Capabilities.GetEnumerator();
            //while (test.MoveNext())
            //{
            //    Console.WriteLine(test.Current);
            //}
            //MemberInfo[] memberInfo=vaultClient.V1.Secrets.KeyValue.GetType().GetMembers();
            //foreach(MemberInfo mem in memberInfo){
            //    Console.WriteLine(mem.Name);
            //}

            var result = await vaultClient.V1.Secrets.KeyValue.V1.ReadSecretAsync("mssqlsecret", "secret", null);

            return result.Data;

        }
    }
}
