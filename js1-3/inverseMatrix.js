const WolframAlphaApi = require('wolfram-alpha-api');
const waApi = WolframAlphaApi('UJYUY4-48JXVQA9PV');
const util = require('util');
const matrix = require('./matrix');

const TEST = require('./modules/test');


console.log('started');
//const inputSum = 'sum ((-1)^k*x^(3*k))/(2*k+1)!, k=0 to +oo';
const inputMatrix = `inverse ${matrix}`;

//console.log(util.inspect(inputMatrix));
waApi.getFull(inputMatrix).then(
    response => {
        console.log(matrix.replace(/},/g, '\n').replace(/[{},]/g, ''));
        const a = (matrix.replace(/},/g, '\n').replace(/[{},]/g, ''));
        const inverted = response.pods[2].subpods[0].img.alt;
        //console.log(util.inspect(response, false, 8, true));
        const cleanInvertedMatrix = inverted.replace(/[()|]/g, '');
        console.log(cleanInvertedMatrix);
        const res = [];
        TEST(cleanInvertedMatrix, a);
    },
    error => {
        console.log(util.inspect(error));
    }
).catch(console.error);

const ТЕСТ = (mat, inv) => {
    const res = [];
        for (let i = 0; i <= 2; i++){
            for (let j = 0; j <= 0; j++){
                res [i,j] = inverted[j]*matrix[i];
            }
            console.log('\n')
        }
}