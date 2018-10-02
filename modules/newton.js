const dividedDifferencesMatrix = () => (arrayX,arrayY:Array<Double>):Array<Array<Double>>{
    let mat = Array(arrayX.size, {Array(arrayX.size,{0.0})});

    for(i in 0 until 5){
        mat[0][i] = arrayY[i]
    }

    for(i in 0 until 4){
        val chis: Double = (mat[0][i+1] - mat[0][i])
        val znam: Double = arrayX[i+1] - arrayX[i]
        mat[1][i] = chis/znam
    }
    for(i in 0 until 3){
        val chis: Double = (mat[1][i+1] - mat[1][i])
        val znam: Double = arrayX[i+2] - arrayX[i]
        mat[2][i] = chis/znam
    }
    for(i in 0 until 2){
        val chis: Double = (mat[2][i+1] - mat[2][i])
        val znam: Double = arrayX[i+3] - arrayX[i]
        mat[3][i] = chis/znam
    }
    for(i in 0 until 1){
        val chis: Double = (mat[3][i+1] - mat[3][i])
        val znam: Double = arrayX[i+4] - arrayX[i]
        mat[4][i] = chis/znam
    }

    return mat
}
fun NewtonInterpolation(arrayX: Array<Double>,arrayY: Array<Double>, arrayXMid: Array<Double>):Array<Double>
{
    var arrayG:Array<Double> = Array(arrayX.size-1){i->(0.0)}
    println("arrayG = ${arrayX.size-1} arrayXMid = ${arrayXMid.size} arrayX =  ${arrayX.size}")
    for(i in 0 until arrayXMid.size){
        var Nn = arrayY[0]
        var koef = 1.0
        val dividedDifferencesMatrix = dividedDifferencesMatrix(arrayX,arrayY)
        var j = 1
        while(j<arrayX.size-1){
            koef*= arrayXMid[i] - arrayX[j-1]
            Nn+= koef*dividedDifferencesMatrix[j][0]
            j++
        }
        print(i)
        arrayG[i] = Nn
    }




    return arrayG
}
fun main(args:Array<String>){

    val ArrayX = arrayOf(-1.0,-0.5,0.0,0.5,1.0)
    val ArrayY = arrayOf(18.8,8.33,0.0,-8.33,-18.8)
    var arrayXMid = Array<Double>(ArrayX.size-1){i->(0.0)}
    for(i in 0 until arrayXMid.size) arrayXMid[i.toInt()] = (ArrayX[i.toInt()]+ArrayX[i.toInt()+1])/2
    val G = NewtonInterpolation(ArrayX,ArrayY,arrayXMid)

    println("x = ${ArrayX[0]}        f(${ArrayX[0]}) = ${ArrayY[0]}")
    for(i in 0 until G.size){
        println("x_cр = ${arrayXMid[i]}     g(${arrayXMid[i]}) = ${G[i]}")
        println("x =${ArrayX[i+1]}        f(${ArrayX[i+1]})= ${ArrayY[i+1]}")
    }


}