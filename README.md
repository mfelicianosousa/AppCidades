# AppCidades


# Sobre o projeto
Projeto Inicial para Cidades Inteligentes

AppCidades é uma aplicação full stack web, inicialmente construída para testes, evento organizado pelo programa de Trainee 2020 [Squadra Digital - New Thinkers ](https://www.squadra.com.br/ "Site da Squadra").
A aplicação consiste em desenvolver uma API EM C# de qualquer objeto a revelia do aluno, sendo um crud que depois será evoluido, utilizando boas práticas 
de desenvolvimento, tais como DDD, testes unitários.


# Tecnologias utilizadas
## Back end
- C#
- EF
- Postman
- 
## Front end
- HTML / CSS / JS / TypeScript
- ReactJS
- React Native

## Implantação em produção
- Back end: Local

- Banco de dados: Postgresql

# Como executar o projeto

## Back end
Pré-requisitos: dotnet.5

```bash
# clonar repositório
https://github.com/mfelicianosousa/AppCidades.git


```

## Front end web
Pré-requisitos: npm / yarn

## Métodos
Requisições para a API devem seguir os padrões:
| Método | Descrição |
|---|---|
| `GET` | Retorna informações de um ou mais registros. |
| `POST` | Utilizado para criar um novo registro. |
| `PUT` | Atualiza dados de um registro ou altera sua situação. |
| `DELETE` | Remove um registro do sistema. |

## Respostas

| Código | Descrição |
|---|---|
| `200` | Requisição executada com sucesso (success).|
| `400` | Erros de validação ou os campos informados não existem no sistema.|
| `401` | Dados de acesso inválidos.|
| `404` | Registro pesquisado não encontrado (Not found).|
| `405` | Método não implementado.|
| `410` | Registro pesquisado foi apagado do sistema e não esta mais disponível.|
| `422` | Dados informados estão fora do escopo definido para o campo.|
| `429` | Número máximo de requisições atingido. (*aguarde alguns segundos e tente novamente*)|

#### Dados para envio no POST

### Listar todos (AllList) [GET]

http://localhost:5000/api/pessoa/

+ Request (application/json)

    
+ Response 200 (application/json)
    [
        {
            "id": 1,
            "nome": "Marcelino",
            "sexo": "M",
            "cpf": "06656087674",
            "email": "marcelino.feliciano@gmail.com"
        }
    ]

### Novo ( Add ) [POST]

+ host 
    http://localhost:5000/api/pessoa
    
    Deve se preencher o Body (Corpo da requisição) sem o identificador. 
    O identificador é gerado automáticamente.

+ Attributes (object)
  + nome: nome da pessoa (String, required) - limite 60 caracteres
  + sexo: (string, required) - 1 caractere
  + cpf: (string, required) - 11 caracretes
  + email: (string, required) - limite 100 caracteres

+ Request (application/json)

    + Headers

 + Body

    {
        "nome": "Marcelino",
        "sexo": "M",
        "cpf": "06656087674",
        "email": "marcelino.feliciano@gmail.com"
    }
    
+ Response 200 (application/json)

    + Headers

            X-RateLimit-Limit: 60
            X-RateLimit-Remaining: 59

    + Body

           {
              "id": 1,
              "nome": "Marcelino",
              "sexo": "M",
              "cpf": "06656087674",
              "email": "marcelino.feliciano@gmail.com"
           }
           
 ### Buscar por Id FindById() [GET  /api/pessoa/{id}]
 
 + Host 

    + http://localhost:5000/api/pessoa/4

Obs: No Body deve se passar a {} vazio
Se não passar vai dar erro na hora de retornar o registro json 

+ Body

     {}
     
+ Request (application/json)

    + Headers
           None

+ Response 200 (application/json)

    + Headers

            X-RateLimit-Limit: 60
            X-RateLimit-Remaining: 59

    + Body       

### Editar (Update) [PUT /api/pessoa/{1}]

+ Host 

  http://localhost:5000/api/pessoa

Obs: Para efetuar as alterações o id deve também ser passado no corpo da requisição

+ Request (application/json)

    + Headers

            none
    + Body
        {
            "id": 1,             
            "nome": "Marcelino F Sousa",
            "sexo": "M",
            "cpf": "06656087674",
            "email": "marcelino@gmail.com"
        }
        
  + Response 200 (application/json)
  
  Todos os dados da pessoa
    + Headers

            X-RateLimit-Limit: 60
            X-RateLimit-Remaining: 58

    + Body
        {
            "id": 1,
            "nome": "Marcelino F Sousa",
            "sexo": "M",
            "cpf": "06656087674",
            "email": "marcelino@gmail.com"
        }
        
 ### Remover (Delete) [DELETE  /api/pessoa/{id}]
 
 + Host 

    + http://localhost:5000/api/pessoa/4


+ Request (application/json)

    + Headers

            Authorization: Bearer [access_token]

+ Response 200 (application/json)

    + Headers

            X-RateLimit-Limit: 60
            X-RateLimit-Remaining: 59

    + Body       

# Autor

Marcelino Feliciano de Sousa

https://www.linkedin.com/in/marcelino-feliciano-b5076024/

