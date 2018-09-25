const POINTLEFT = -0.5;
const POINTRIGHT = 0.5;
const STEP = 0.1
const DEBUG = true;
const originalFunct = (x) => {
    return 1/Math.sqrt(1 - Math.pow(x,2));
}

const fX = [];
const pointsArray = [];
let currentPoint = POINTLEFT;
while (currentPoint <= POINTRIGHT){
    const result = originalFunct(currentPoint);
    DEBUG && console.log(` ${currentPoint.toFixed(1)}  ${result}`);
    fX.push(result);
    pointsArray.push(currentPoint);
    currentPoint += STEP;
}


const pointsArrayForInterpolation = [];
for (let i = 1; i < pointsArray.length; i++ ){
    const point = (pointsArray[i-1] + pointsArray[i])/2;
    pointsArrayForInterpolation.push(point);
}
console.log(fX);
console.log(pointsArrayForInterpolation);



