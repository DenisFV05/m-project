$(document).ready(function () {
    $("#buscar").on("click", function () {
        const query = $("#last_name2").val().trim();

        if (!query) {
            console.log("Introduce un nombre para buscar.");
            return;
        }

        const url = `https://api.pokemontcg.io/v2/cards?q=name:${query}`;

        fetch(url, {
            headers: {
                "X-Api-Key": "66fd7811-296d-4992-b541-c9e4ef566c4d"
            }
        })
        .then(response => response.json())
        .then(data => {
            if (!data.data || data.data.length === 0) {
                console.log("No se encontraron cartas.");
                return;
            }

            const carddatatrobat = $("#llista");
            carddatatrobat.empty(); 

            data.data.forEach(card => {
                const newElem = $(`
                    <li class="collection-item" data-id="${card.id}">
                        <a href="#!" class="collection-item">
                            <img src="${card.images.small}" alt="${card.name}" width="50"> ${card.name}
                        </a>
                    </li>
                `);
                carddatatrobat.append(newElem);
            });

            console.log(data.data); 
        })
        .catch(error => {
            console.error("Error en la búsqueda:", error);
        });
    });

    $(document).on("click", ".collection-item", function () {
        const cardId = $(this).data("id");

        if (!cardId) return;

        const url = `https://api.pokemontcg.io/v2/cards/${cardId}`;

        fetch(url, {
            headers: {
                "X-Api-Key": "0417ac7c-6b58-4a9c-83cb-91594d94e384"
            }
        })
        .then(response => response.json())
        .then(data => {
            if (!data.data) {
                console.log("No se encontró la carta.");
                return;
            }

            const card = data.data;
            const carddata = $("#info");
            carddata.html(`
                <h3>${card.name}</h3>
                <img src="${card.images.large}" id="carddataimg"/>
                <p>HP: ${card.hp}</p>
                <p>Supertipo: ${card.supertype}</p>
                <p>Subtipos: ${card.subtypes.join(", ")}</p>
                <p>Tipo(s): ${card.types ? card.types.join(", ") : "Desconocido"}</p>
                <p>Evoluciona a: ${card.evolvesTo ? card.evolvesTo.join(", ") : "No evoluciona"}</p>
            `);

        })
        .catch(error => {
            console.error("Error al obtener la carta:", error);
        });
    });
});