
const fs = require('fs');

let width = 16;

const screenWidth = 1920;
const screenHeight = 1080;

const results = [];

console.log("calculating results!");

while (width < 2000) {
    let height = width / (4 / 3);

    if (screenWidth % width === 0 && screenHeight % height === 0 && height % 16 === 0) {
        console.log("result found");
        results.push({ x: width, y: height });

    }

    console.log("width: " + width + " height:" + height);
    width += 16;
}


const data = JSON.stringify(results);
console.log(data);

fs.writeFile("resolutions.json", data, () => {
    console.log("done!");
});

