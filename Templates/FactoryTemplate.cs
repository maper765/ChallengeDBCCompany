using System;

namespace ChallengeDBCCompany.Templates
{
    public class FactoryTemplate
    {
		public static ITemplate Make(string formatId)
		{
			var namespaceTemplate =
				$"ChallengeDBCCompany.Templates.Template{formatId}";
			Type classe = Type.GetType(namespaceTemplate);

			return Activator.CreateInstance(classe) as ITemplate;
		}
	}
}
