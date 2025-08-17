# 📌 API REST

Este repositório contém a implementação de uma **API RESTful** desenvolvida em **C#**.  

---

## 🔎 O que é uma API REST?
**API REST (Representational State Transfer)** é um estilo de arquitetura para construção de serviços web.  
Ela define regras e boas práticas para que sistemas diferentes possam se comunicar de forma simples e padronizada usando o protocolo **HTTP**.  

As principais características de uma API REST são:
- Utiliza os verbos HTTP (`GET`, `POST`, `PUT`, `DELETE`, etc.);
- Trabalha com recursos identificados por **URLs**;
- Retorna respostas em formato **JSON** (ou XML, quando necessário);
- É **stateless**, ou seja, não mantém estado entre as requisições;
- Facilita integração entre sistemas de forma rápida e escalável.

Exemplo:  
- `GET /api/filme` → retorna todos os Filme  
- `POST /api/filme` → cria um novo Filme
