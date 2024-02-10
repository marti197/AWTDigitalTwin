
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Map;
using Unity;


public class Test : MonoBehaviour
{
    public AbstractMap Map;
    public PresetFeatureType type;
    private void Update()
    {

        //Mapbox.VectorTile.VectorTileLayer layer = Map.Tiles.GetLayer("Buildings");
        var test = Map.VectorData;
        //var options = Map.Options;
        //VectorLayerProperties layerProp = test.LayerProperty;

        VectorSubLayerProperties subLayer = PresetSubLayerPropertiesFetcher.GetSubLayerProperties(type);
        //var layerProperty = test.FindPropertyRelative("_layerProperty");
        //_vectorLayerDrawer.PostProcessLayerProperties(layerProperty);
        subLayer.coreOptions.isActive = false;
        //test.SetProperties(subLayer);
        //subLayer.RemoveFeatureSubLayer();
        //test.GetStyleType();


        //Mapbox.VectorTile.VectorTileLayer layer = Map.Tiles.GetLayer("Buildings");

        var subLayerProperties = PresetSubLayerPropertiesFetcher.GetSubLayerProperties(type);


        //var subLayerCoreOptions = PresetSubLayerPropertiesFetcher.FindPropertyRelative("coreOptions");
        //bool isLayerActive = subLayerCoreOptions.FindPropertyRelative("isActive").boolValue;
        //coreOptions.FindPropertyRelative("isActive").boolValue = false;

        //var test3 = VectorSubLayerProperties.SubLayerNameMatchesExact("Buildings");

        //var test4 = VectorSubLayerProperties.Key("Buildings");


        //var test10 = VectorLayerPropertiesDrawer.


    }
}




