﻿/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// A class encapsulating the property map of the mesh visual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class MeshVisual : VisualMap
    {
        private string objectURL;
        private string materialURL;
        private string texturesPath;
        private MeshVisualShadingModeValue? shadingMode;
        private bool? useMipmapping;
        private bool? useSoftNormals;
        private Vector3 lightPosition;

        /// <summary>
        /// Default constructor of MeshVisual class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public MeshVisual() : base()
        {
        }

        /// <summary>
        /// Gets or sets the location of the ".obj" file.<br />
        /// Mandatory.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string ObjectURL
        {
            get
            {
                return objectURL;
            }
            set
            {
                objectURL = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the location of the ".mtl" file.<br />
        /// If not specified, then a textureless object is assumed.<br />
        /// Optional.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string MaterialURL
        {
            get
            {
                return materialURL;
            }
            set
            {
                materialURL = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the location of the ".mtl" file.<br />
        /// If not specified, then a textureless object is assumed.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string MaterialtURL
        {
            get
            {
                return materialURL;
            }
            set
            {
                materialURL = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the path to the directory the textures (including gloss and normal) are stored in.<br />
        /// Mandatory if using material.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string TexturesPath
        {
            get
            {
                return texturesPath;
            }
            set
            {
                texturesPath = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the type of shading mode that the mesh will use.<br />
        /// If anything the specified shading mode requires is missing, a simpler mode that can be handled with what has been supplied will be used instead.<br />
        /// If not specified, it will use the best it can support (will try MeshVisualShadingModeValue.TexturedWithDetailedSpecularLighting first).<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public MeshVisualShadingModeValue ShadingMode
        {
            get
            {
                return shadingMode ?? (MeshVisualShadingModeValue.TexturedWithDetailedSpecularLighting);
            }
            set
            {
                shadingMode = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets whether to use mipmaps for textures or not.<br />
        /// If not specified, the default is true.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool UseMipmapping
        {
            get
            {
                return useMipmapping ?? (true);
            }
            set
            {
                useMipmapping = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets whether to average normals at each point to smooth textures or not.<br />
        /// If not specified, the default is true.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool UseSoftNormals
        {
            get
            {
                return useSoftNormals ?? (true);
            }
            set
            {
                useSoftNormals = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the position, in the stage space, of the point light that applies lighting to the model.<br />
        /// This is based off the stage's dimensions, so using the width and the height of the stage halved will correspond to the center,
        /// and using all zeroes will place the light at the top-left corner.<br />
        /// If not specified, the default is an offset outwards from the center of the screen.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector3 LightPosition
        {
            get
            {
                return lightPosition;
            }
            set
            {
                lightPosition = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Compose the out visual map.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void ComposingPropertyMap()
        {
            if (objectURL != null)
            {
                _outputVisualMap = new PropertyMap();
                _outputVisualMap.Add(Visual.Property.Type, (int)Visual.Type.Mesh);
                _outputVisualMap.Add(MeshVisualProperty.ObjectURL, objectURL);

                if (materialURL != null)
                {
                    _outputVisualMap.Add(MeshVisualProperty.MaterialtURL, materialURL);
                }
                if (texturesPath != null)
                {
                    _outputVisualMap.Add(MeshVisualProperty.TexturesPath, texturesPath);
                }
                if (shadingMode != null)
                {
                    _outputVisualMap.Add(MeshVisualProperty.ShadingMode, (int)shadingMode);
                }
                if (useMipmapping != null)
                {
                    _outputVisualMap.Add(MeshVisualProperty.UseMipmapping, (bool)useMipmapping);
                }
                if (useSoftNormals != null)
                {
                    _outputVisualMap.Add(MeshVisualProperty.UseSoftNormals, (bool)useSoftNormals);
                }
                base.ComposingPropertyMap();
            }
        }
    }
}
