# Finanças
Projeto Asp.Net Core Web Api para um sistema financeiro pessoal

## Criação

### Projeto Domain
- Criar a Entidade <Entity>
- Criar a Interface de Repositório da Entidade (Interface) <IEntityRepository>

### Projeto Data
- Criar o Mapping da Entidade <EntityMapping>
- Colocar no Context do Entity o DbSet e o Mapping DbSet<Entity> Entity;
- Implementar a Interface do Repositório da Entidade (Classe Concreta) <EntityRepository>

### Projeto API
- Criar a API e seus Commands
- Ajustar o container de Injeção e Dependências (Pipeline >> NativeInjector.cs)
