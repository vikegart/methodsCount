const funct = (k, x, f) => {
    let q;
    q = (-1) * (x * x) / (4 * (2 * k + 3) * (2 * k + 2));
    return f * q;
}

const main = () =>
{
    let F = [];
    let i = 0;
    let summ = 0;
    let e = 0.00001;
    let f;
    for (let x = 0; x < 1.8; x += 0.1)
    {
        let k = 0;
        f = x / 2;
        while (Math.abs(f) >= e)
        {   
            summ += f;
            let q = (-1) * (x * x) / (4 * (2 * k + 3) * (2 * k + 2));
            f *= q;
            ++k;
        }
        F[i] = summ;
        summ = 0;
        f = x / 2;
        i++;
    }
    let x = 0;
    console.log(`${x}  ${F[0]} `);
    x = x + 0.1;
    console.log(F[1]);
    for (let j = 1; j < 17; ++j)
    {
        console.log( `${x.toFixed(1)} ${Math.sin(x/2)} ${F[j]} ${(F[j]-F[j-1])/0.1} ${(F[j+1] - F[j]) / 0.1} ${((F[j + 1] - F[j]) + (F[j] - F[j - 1]))/0.2} ${(Math.cos(x/2)*0.5)}`);
        x = x + 0.1;
    }
    console.log(`${Math.sin(x / 2)} ${F[17]} ${(Math.cos(x / 2)*0.5)}`);
    return 0;
}

main();