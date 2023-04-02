using Enigma;

// Test website: https://piotte13.github.io/enigma-cipher/

// Examples: https://github.com/caadam/Enigma

var encryptedMessage1 =
    "EDPUD NRGYS ZRCXN UYTPO MRMBO FKTBZ REZKM LXLVE FGUEY SIOZV EQMIK UBPMM YLKLT TDEIS MDICA GYKUA CTCDO MOHWX MUUIA UBSTS LRNBZ SZWNR FXWFY SSXJZ VIJHI DISHP RKLKA YUPAD TXQSP INQMA TLPIF SVKDA SCTAC DPBOP VHJK ";
var encryptedMessage2 =
    "SFBWD NJUSE GQOBH KRTAR EEZMW KPPRB XOHDR OEQGB BGTQV PGVKB VVGBI MHUSZ YDAJQ IROAX SSSNR EHYGG RPISE ZBOVM QIEMM ZCYSG QDGRE RVBIL EKXYQ IRGIR QNRDN VRXCY YTNJR";

EnigmaMachine enigmaMachine = new EnigmaMachine(
    "B", 
    "II IV V", 
    "B L A", 
    "02 21 12", 
    "AV BS CG DL FU HZ IN KM OW RX"
    );

var decryptedMessage1 = enigmaMachine.Decrypt(encryptedMessage1);

enigmaMachine = new EnigmaMachine(
    "B", 
    "II IV V", 
    "L S D", 
    "02 21 12", 
    "AV BS CG DL FU HZ IN KM OW RX"
);

var decryptedMessage2 = enigmaMachine.Decrypt(encryptedMessage2);

Console.WriteLine(decryptedMessage1);
Console.WriteLine(decryptedMessage2);

