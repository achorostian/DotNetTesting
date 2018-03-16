#### Korzystanie z biblioteki "System" przy pomocy Visual Studio 2017

Po dodaniu fake'�w do naszej biblioteki pojawi� si� errory. By si� ich pozby� nale�y przeedytowa� plik "mscorlib.fakes". Okre�lamy w nim co robimy z wygenerowanymi Shimami.
Dodajemy do pliku taki fragment kodu:

 <Assembly Name="mscorlib" Version="4.0.0.0"/>
  <StubGeneration>
    <Clear/>
  </StubGeneration>
  <ShimGeneration>
    <Clear/>
    <Add FullName="System.IO.File"/>
    <Remove FullName="System.IO.FileOptions"/>
    <Remove FullName="System.IO.FileAttributes"/>
    <Remove FullName="System.IO.FileAccess"/>
    <Remove FullName="System.IO.FileSystemEnumerableFactory"/>
    <Remove FullName="System.IO.FileShare"/>
    <Remove FullName="System.IO.FileSystemEnumerableIterator"/>
    <Remove FullName="System.IO.FileStreamAsyncResult"/>
    <Remove FullName="System.IO.FileSecurityStateAccess"/>
    <Remove FullName="System.IO.FileInfoResultHandler"/>
    <Remove FullName="System.IO.FileStream+FileStreamReadWriteTask"/>
    <Remove FullName="System.IO.FileMode"/>
    <Remove FullName="System.IO.FileSystemInfoResultHandler"/>
    <Remove FullName="System.IO.FileStream+"/>
    <Remove FullName="System.IO.FileSystemEnumerableHelpers"/>

  </ShimGeneration>
  
Podany fragment kodu usuwa te funkcjonalno�ci biblioteki "System" kt�re nie mog� by� Shimami, np te kt�remaj� metody statyczne. To powinno za�atwi� spraw�.