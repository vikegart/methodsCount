const TEST = (a, b) => {
    const matA = [
        [0, 1 ,2],
        [1, 5, 2],
        [0, 1, 7]
    ];
    const matB = [
        [-33/5, 1 , 8/5],
        [7/5, 0, -2/5],
        [-1/5, 0, 1/5]
    ];
    console.log(matB);
    const res = [];
        for (let i = 0; i <= 2; i++){
            for (let j = 0; j <= 2; j++){
                for (let k = 0; k <= 2; ++k)
                        res[i, j] += matB[i, k] * matA[k, j]; 

            }
        }
        console.log(res);
}

module.exports = TEST;