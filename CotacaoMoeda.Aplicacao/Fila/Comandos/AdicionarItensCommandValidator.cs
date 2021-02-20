using FluentValidation;

namespace CotacaoMoeda.Aplicacao.Fila.Comandos
{
    public class AdicionarItensCommandValidator : AbstractValidator<AdicionarItensCommand>
    {
        public AdicionarItensCommandValidator()
        {
            RuleFor(x => x.Itens).NotNull();
            RuleForEach(x => x.Itens).ChildRules(x => x.RuleFor(y => y.Moeda).IsInEnum());
            RuleForEach(x => x.Itens).ChildRules(x => x.RuleFor(y => y.Data_Inicio).NotNull().NotEmpty());
            RuleForEach(x => x.Itens).ChildRules(x => x.RuleFor(y => y.Data_Fim).NotNull().NotEmpty());
        }
    }
}
