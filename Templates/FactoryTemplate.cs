using System;

namespace ChallengeDBCCompany.Templates
{
	/// <summary>
	///		Cria instância para o template de atributos do relatório.
	/// </summary>
    public class FactoryTemplate
    {
		/// <summary>
		///		Obtêm uma instância para a implementação de 
		///		<see cref="ITemplate"/>.
		/// </summary>
		/// <param name="formatId">Código que identifica o template.</param>
		/// <returns>Instância de <see cref="ITemplate"/>.</returns>
		public static ITemplate GetInstance(string formatId) =>
			Activator.CreateInstance(
				Type.GetType(
					$"ChallengeDBCCompany.Templates.Template{formatId}")) as ITemplate;
	}
}
