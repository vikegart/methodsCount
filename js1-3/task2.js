const lagrange = require('./modules/lagrange');
const newtonInterpol = require('./modules/newtonWork');

const POINTLEFT = -0.5;
const POINTRIGHT = 0.5;
const STEP = 0.1
const DEBUG = true;
const originalFunct = (x) => {
    return 1 / Math.sqrt(1 - Math.pow(x, 2));
}

const fX = [];
const pointsArray = [];
let currentPoint = POINTLEFT;
while (currentPoint <= POINTRIGHT) {
    const result = originalFunct(currentPoint);
    DEBUG && console.log(` ${currentPoint.toFixed(1)}  ${result}`);
    fX.push(result);
    pointsArray.push(currentPoint);
    currentPoint += STEP;
}


const pointsArrayForInterpolation = [];
for (let i = 1; i < pointsArray.length; i += 1) {
    const point = (pointsArray[i - 1] + pointsArray[i]) / 2;
    pointsArrayForInterpolation.push(point);
}
//console.log(fX);
//console.log(pointsArrayForInterpolation);

let x = POINTLEFT;
for (let j = 1; j < fX.length; j += 1) {
    x += STEP;
    let a1, a0;
    a1 = (fX[j] - fX[j - 1]) / (x + 0.05 - x + 0.05);
    a0 = fX[j - 1] - (x - 0.05) * a1;
    console.log(` ${x.toFixed(1)} ${(a1 * x + a0).toFixed(1)} ${fX[j].toFixed(1)}`);
}

let beanArray = [];
let tempPoint = -0.5;
fX.forEach((value) => {
    beanArray.push([tempPoint, value]);
    tempPoint += 1;
})

console.log(beanArray);

let funcionByLagrange = lagrange(beanArray);
pointsArrayForInterpolation.forEach((point) => {
    console.log(funcionByLagrange(point));
})



//call with bean?
newtonInterpol(pointsArray, fX);
console.log(newtonInterpol(pointsArray, fX));

