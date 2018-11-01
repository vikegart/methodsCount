const WolframAlphaApi = require('wolfram-alpha-api');
const waApi = WolframAlphaApi('UJYUY4-48JXVQA9PV');
const util = require('util');

console.log('started');
const input = 'sum ((-1)^k*x^(3*k))/(2*k+1)!, k=0 to +oo';

console.log(util.inspect(input));
waApi.getFull(input).then(
    response => {
        console.log(util.inspect(response, false, 8, true));
    },
    error => {
        console.log(util.inspect(error));
    }
).catch(console.error);