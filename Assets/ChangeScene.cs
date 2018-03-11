/////////////////////////////////////////////////
//                  CREATE                      
//Author:       Grzegorz Jaruszewski
//Date:         2017-11-12
//Description:  Obracanie obiektu
/////////////////////////////////////////////////
//                  CHANGE                      
//Author:       Piotr Arent
//Date:         2017-11-21
//Description:  Usunięcie komentarza do metody update która została usunięta metaforyczne 100 lat temu.
/////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour {

	public void ChangeToScene (string sceneToChangeTo) {
        Application.LoadLevel(sceneToChangeTo);
	}
}
