int imageCount = 52;
int imagesInRow = 3;

int filledRowCount = imageCount / imagesInRow;
int imageOutRow = imageCount % imagesInRow;

Console.WriteLine("Всего заполнен рядов "+ filledRowCount + ", картинок сверх меры "+ imageOutRow);