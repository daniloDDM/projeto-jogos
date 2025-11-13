# **GRUPO A:** Echoes of Valhalla
Trabalho de Desenvolvimento de Jogos apresentado ao Centro Universitário [FEI](https://portal.fei.edu.br/), como parte dos requisitos necessários para aprovação na disciplina de Desenvolvimento de Jogos Digitais (CC7140) do curso de Ciência da Computação, orientado pelo Prof. Dr. [Fagner de Assis Moura Pimentel](https://github.com/fagnerpimentel).

## Componentes do Grupo

- Danilo Miranda - 22.221.037-9
- Gabriel Balbine - 22.222.001-4
- Iago Rosa de Oliveira - 22.224.027-7
- Sergio Martins - 22.222.021-2
- Luiggi Garcia - 22.122.006-4

## Tópicos.
- [Introdução](./docs/1-introducao.md)
- [Público Alvo](./docs/2-publico-alvo.md)
- [Estética](./docs/3-estetica.md)
- [Dinâmica](./docs/4-dinamica.md)
- [Mecânica](./docs/5-mecanica.md)
- [Prefabs](./docs/6-prefabs.md)
- [Prototipação](./docs/7-prototipacao.md)
- [Testes](./docs/8-testes.md)

## Link para vídeo de apresentação do projeto:
https://drive.google.com/file/d/1gXMnBQz3OH4sTwa_gxbJ13E-RSuhwhLC/view?usp=sharing

---

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

PRINCIPAIS:
- [Yvar](https://www.spriters-resource.com/game_boy_advance/fireemblemtheblazingblade/asset/14107/)
- [Odin](https://www.spriters-resource.com/ds_dsi/thorgodofthunder/asset/56859)
- [Thor](https://www.spriters-resource.com/browser_games/marvelavengers/asset/67202)
- [Loki](https://www.spriters-resource.com/browser_games/marvelavengers/asset/57793)

NIFLHEIN:
- [Jormag: boss Niflheim](https://www.spriters-resource.com/mobile/projectcleanearth/asset/485799)
- [Ice Spirit (Niflheim)](https://www.spriters-resource.com/mobile/dhl4/asset/60441)
- [Ice Golem (Niflheim)](https://www.spriters-resource.com/game_boy_advance/snight2/asset/20733)

HELHEIM:
- [Gullin: boss Helheim](https://www.spriters-resource.com/ms_dos/witchaven/asset/30897)
- [Skeleton Warrior (Helheim)](https://www.spriters-resource.com/mobile/demonhuntlgnd/asset/44639)
- [Spectre (Helheim)](https://www.spriters-resource.com/ds_dsi/castlevaniaorderofecclesia/asset/19221)
- [Spectre 2 (Helheim)](https://www.spriters-resource.com/pc_computer/koumajoudensetsuiistrangersrequiem/asset/88787)

MUSPELHEIM:
- [Surtr: boss Muspelheim](https://www.spriters-resource.com/pc_computer/mnmvii/asset/43154)
- [Fire Lion (Muspelheim)](https://www.spriters-resource.com/game_boy_advance/kirbynim/asset/2963)
