window.onload = (event) => {
    InitVysorTable();
    SetStageForm();
};

let StageObjects = []

let StageForm = {
    IStageName: null,
    IStageColor: null,
    BtnAddStage: null,
    BtnClearVysor: null,
    DisableEditStages: null,
}

const SetStageForm = () => {

    StageForm.IStageName = document.getElementById("stageName");
    StageForm.IStageColor = document.getElementById("stageColor");
    StageForm.BtnAddStage = document.getElementById("BtnAddStage");
    StageForm.BtnClearVysor = document.getElementById("BtnClearVysor");
    StageForm.DisableEditStages = document.getElementById("DisableEditStages");

    StageForm.BtnAddStage.onclick = AddStage;
    StageForm.BtnClearVysor.onclick = ClearVysor;



}

const AddStage = () => {

    const NewStage = {
        color: StageForm.IStageColor.value,
        posX: 0,
        posY: 0,
        sizeH: 100,
        sizeW: 100,
        stage: {
            name: StageForm.IStageName.value,
            stageId: 5
        },
        stageId: 5,
        vysor: null,
        vysorId: 1
    }

    InitStages(NewStage);

}

const ClearVysor = () => {

    StageObjects.forEach((item) => {
        item.DomElement.remove();
    })

    StageObjects = [];


}

const DisableEditStages = () => {

    console.log(StageForm.DisableEditStages.checked)

}


const InitVysorTable = () => {

    const myHeaders = new Headers();
    myHeaders.append("Accept", "application/json");

    const requestOptions = {
        method: "GET",
        headers: myHeaders,
        redirect: "follow"
    };

    fetch("/api/Vysor/GetAll", requestOptions)
        .then((response) => response.json())
        .then((result) => {
            document.getElementById("VysorTableContent")
                .innerHTML = result.map((item) => `<tr><td><button vysorId=${item.vysorId} id=BtnVysor${item.vysorId}>${item.name}</button></td></tr>`).join('');

            result.forEach((item) => {

                document.getElementById(`BtnVysor${item.vysorId}`).onclick = (i) => {
                    InitVysorInfo(i.target.attributes["vysorId"].value)
                }
            })
        })
        .catch((error) => console.error(error));

}

const InitVysorInfo = (id) => {

    const myHeaders = new Headers();
    myHeaders.append("Accept", "application/json");

    const requestOptions = {
        method: "GET",
        headers: myHeaders,
        redirect: "follow"
    };

    fetch("/api/Vysor/GetValueById?id=" + id, requestOptions)
        .then((response) => response.json())
        .then((result) => {

            //console.log('InitVysorInfo', result)
            GetStages(id)

        })
        .catch((error) => console.error(error));


}

const GetStages = (id) => {

    const myHeaders = new Headers();
    myHeaders.append("Accept", "application/json");

    const requestOptions = {
        method: "GET",
        headers: myHeaders,
        redirect: "follow"
    };

    fetch("/api/VysorStage/GetListByVysor?id=" + id, requestOptions)
        .then((response) => response.json())
        .then((result) => {
            //console.log('GetStages', result)
            StageObjects = [];

            result.forEach((item) => {
                //console.log(item)
                InitStages(item);
            })

        })
        .catch((error) => console.error(error));


}

const InitStages = (item) => {

    let StageProps = {
        id: item.stage.stageId,
        data: item,
        DomElement: null,
        IntObject: null
    }

    StageProps.DomElement = DomStage(item);

    document.getElementById('VysorContainer').appendChild(StageProps.DomElement);

    let x = item.posX;
    let y = item.posY;

    StageProps.IntObject = interact(StageProps.DomElement)
        .draggable({
            modifiers: [
                interact.modifiers.snap({
                    targets: [
                        interact.snappers.grid({ x: 10, y: 10 })
                    ],
                    range: Infinity,
                    relativePoints: [{ x: 0, y: 0 }]
                }),
                interact.modifiers.restrict({
                    restriction: StageProps.DomElement.parentNode,
                    elementRect: { top: 0, left: 0, bottom: 1, right: 1 },
                    endOnly: true
                })

            ],
            inertia: true
        })
        .resizable({
            edges: { top: true, left: true, bottom: true, right: true },
            listeners: {
                move: function (event) {

                    if (StageForm.DisableEditStages.checked) {
                        return;
                    }


                    let { x, y } = event.target.dataset

                    x = (parseFloat(x) || 0) + event.deltaRect.left
                    y = (parseFloat(y) || 0) + event.deltaRect.top

                    Object.assign(event.target.style, {
                        width: `${decimalAdjust('round', event.rect.width, 1)}px`,
                        height: `${decimalAdjust('round', event.rect.height, 1)}px`,
                        //transform: `translate(${0}px, ${0}px)`
                    })
                    Object.assign(event.target.dataset, { x, y })

                }
            },
        })
        .on('dragmove', function (event) {

            if (StageForm.DisableEditStages.checked) {
                return;
            }

            x += event.dx
            y += event.dy

            //console.log(`translate(${decimalAdjust('round', x, 1)}px, ${decimalAdjust('round', y, 1)}px)`)

            x = decimalAdjust('round', x, 1);
            y = decimalAdjust('round', y, 1);

            event.target.style.transform = 'translate(' + x + 'px, ' + y + 'px)'
        })


    StageObjects.push(StageProps)

}


const decimalAdjust = (type, value, exp) => {
    // Si el exp no está definido o es cero...
    if (typeof exp === "undefined" || +exp === 0) {
        return Math[type](value);
    }
    value = +value;
    exp = +exp;
    // Si el valor no es un número o el exp no es un entero...
    if (isNaN(value) || !(typeof exp === "number" && exp % 1 === 0)) {
        return NaN;
    }
    // Shift
    value = value.toString().split("e");
    value = Math[type](+(value[0] + "e" + (value[1] ? +value[1] - exp : -exp)));
    // Shift back
    value = value.toString().split("e");
    return +(value[0] + "e" + (value[1] ? +value[1] + exp : exp));
}


const DomStage = (item) => {

    let DomElement = document.createElement('div');
    DomElement.id = 'Stage' + item.stage.stageId;
    DomElement.className = 'StageContainer';
    DomElement.style.backgroundColor = item.color;
    DomElement.style.width = item.sizeW + 'px';
    DomElement.style.height = item.sizeH + 'px';
    DomElement.style.transform = 'translate(' + item.posX + 'px, ' + item.posY + 'px)'

    DomElement.innerHTML = item.stage.name;

    return DomElement

}
