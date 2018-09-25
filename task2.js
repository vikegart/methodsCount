const POINTLEFT = -0.5;
const POINTRIGHT = 0.5;
const originalFunct = (x) => {
    return 1/Math.sqrt(1 - Math.pow(x,2));
}

const fX = [];
let currentPoint = POINTLEFT;
while (currentPoint <= POINTRIGHT){
    const result = originalFunct(currentPoint);
    console.log(` ${currentPoint.toFixed(1)}  ${result}`);
    fX.push(result);
    currentPoint += 0.1;
}

console.log(fX);
