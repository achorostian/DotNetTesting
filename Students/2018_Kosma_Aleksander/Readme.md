#### Korzystanie z biblioteki "System" przy pomocy Visual Studio 2017

Po dodaniu fake'ów do naszej biblioteki pojawi¹ siê errory. By siê ich pozbyæ nale¿y przeedytowaæ plik "mscorlib.fakes". Okreœlamy w nim co robimy z wygenerowanymi Shimami.
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
  
Podany fragment kodu usuwa te funkcjonalnoœci biblioteki "System" które nie mog¹ byæ Shimami, np te któremaj¹ metody statyczne. To powinno za³atwiæ sprawê.