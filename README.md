# 🧩 Fluxo de Trabalho - Projeto Unity

Este guia explica como **criar, atualizar e subir branches** corretamente no repositório do projeto Unity.

---

## 🧱 1. Criar sua branch

Sempre crie uma branch **nova** a partir da branch principal de desenvolvimento (`dev`):

```bash
git checkout dev          # garante que está na dev
git pull origin dev       # atualiza a dev local
git checkout -b feature/seu-nome-da-tarefa
```

🔖 Exemplo: feature/sistema-de-inventario ou fix/bug-camera

## 🔄 2. Manter sua branch atualizada

Antes de subir alterações, sincronize sua branch com a dev para evitar conflitos:

```bash
git checkout dev
git pull origin dev        # baixa últimas atualizações
git checkout feature/sua-branch
git merge dev              # mescla alterações mais recentes
# (resolva conflitos se houver)
```

## ✍️ 3. Fazer commit e subir para o GitHub

Após fazer suas alterações no Unity:

```bash
git add .
git commit -m "feat: adiciona sistema de inventário"
git push -u origin feature/sua-branch
```

O parâmetro -u define o rastreamento remoto, então nas próximas vezes basta git push.

## 🚀 4. Criar Pull Request (PR)

Vá até o repositório no GitHub.

O site sugerirá abrir um Pull Request da sua branch para dev.

Coloque um título claro e uma breve descrição do que foi feito.

Marque alguém para revisar.

## 🧹 5. Boas práticas

Não trabalhe direto na dev ou main.

Commits curtos e descritivos.

Sempre atualize sua branch antes de subir.

Use nomes de branch padronizados:
- feature/ → nova funcionalidade
- fix/ → correção de bug
- hotfix/ → correção urgente
- chore/ → ajustes menores, configs etc.

---

# LINKS SPRITES

- [PLAYER](https://www.spriters-resource.com/game_boy_advance/fireemblemtheblazingblade/asset/14107/
)
