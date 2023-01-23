int imageCount = 52;
int imageInRow = 3;

int filledRowCount = imageCount / imageInRow;
int imageOutRow = imageCount % imageInRow;

Console.WriteLine("Всего заполнен рядов "+ filledRowCount + ", картинок сверх меры "+ imageOutRow);