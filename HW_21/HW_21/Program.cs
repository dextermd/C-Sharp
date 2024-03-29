﻿using HW_21;

List<Poem> poems = new List<Poem>
{
    new Poem(
        "Осень",
        "Александр Блок",
        1900,
        "Листья желтеют, падают, Осень пришла к нам на погост.",
        "Природа"
    ),
    new Poem(
        "Зимняя ночь",
        "Сергей Есенин",
        1916,
        "Зимняя ночь, заснеженный двор. В доме детский плач и звон цепей.",
        "Зима"
    ),
    new Poem(
        "Весенний дождь",
        "Николай Некрасов",
        1842,
        "Дождик пошел; версты по ряби. Дорога темная, мокрая...",
        "Весна"
    ),
    new Poem(
        "Лебедь",
        "Александр Пушкин",
        1836,
        "Белая пеня, как след лебединый, Плывет за лодкой белеющей.",
        "Природа"
    ),
    new Poem(
        "Любовь",
        "Марина Цветаева",
        1924,
        "Любовь — явление крайнее. Как же так?",
        "Любовь"
    )
};

PoetryManager pm = new PoetryManager(poems);
pm.ShowMenu();
