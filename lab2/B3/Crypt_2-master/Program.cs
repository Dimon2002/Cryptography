using Crypt_2;

Console.WriteLine("Input p and q: ");

var numbers = Reader.ConsoleRead();

while (!Reader.IsPrime(numbers[0]) || !Reader.IsPrime(numbers[1]))
{
    Console.WriteLine("Input p and q: ");
    numbers = Reader.ConsoleRead();
}

var p = numbers[0];
var q = numbers[1];

var n = Computer.ComputeN(p, q);
var lambdaN = Computer.ComputeLambdaN(p - 1, q - 1);
var exp = Computer.GenerateExp(lambdaN);
var d = Computer.ComputeD(exp, lambdaN);

Console.WriteLine($"Public key: {(n, exp)}");
Console.WriteLine($"Private key: {(n, d)}");

Console.WriteLine("Input M: ");
var plainText = Reader.PlainTextRead();

Console.WriteLine("Input public key: ");
var publicKey = Reader.ConsoleRead();

var cipherText = RSAEncoder.Encode(plainText, publicKey[0], publicKey[1]);
Console.WriteLine($"Зашифрованнный текст: {cipherText}");

Console.WriteLine("Input private key: ");
var privateKey = Reader.ConsoleRead();

plainText = RSADecoder.Decode(cipherText, privateKey[0], privateKey[1]);

Console.WriteLine($"Расшифрованный текст: {plainText}");

//65521
//65519