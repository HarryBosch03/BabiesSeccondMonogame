using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BabiesSeccondGame
{
    public static class Drawinator
    {
        static BasicEffect effect;

        static Matrix worldMatrix, viewMatrix, projectionMatrix;

        static VertexBuffer vertBuffer;
        static IndexBuffer triBuffer;

        public static List<VertexPositionColor> Vertices = new();
        public static List<UInt16> Triangles = new();

        static GraphicsDevice Device => MyGame.Instance.GraphicsDevice;

        public static void Initalize ()
        {

        }

        public static void LoadContent ()
        {
            worldMatrix = Matrix.Identity;
            viewMatrix = Matrix.CreateLookAt(new Vector3(0.0f, 0.0f, 5.0f), Vector3.Zero, Vector3.UnitX);
            projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, Device.Viewport.AspectRatio, 1.0f, 10.0f);

            effect = new BasicEffect(Device);
            effect.World = worldMatrix;
            effect.View = viewMatrix;
            effect.Projection = projectionMatrix;
            effect.VertexColorEnabled = true;

            vertBuffer = new(Device, VertexPositionColor.VertexDeclaration, -1, BufferUsage.WriteOnly);
            triBuffer = new(Device, IndexElementSize.SixteenBits, -1, BufferUsage.WriteOnly);
        }

        public static void Draw ()
        {
            effect.World = worldMatrix;
            effect.View = viewMatrix;

            vertBuffer.SetData(Vertices.ToArray(), 0, Vertices.Count);
            triBuffer.SetData(Triangles.ToArray(), 0, Triangles.Count);

            Vertices.Clear();
            Triangles.Clear();

            Device.SetVertexBuffer(vertBuffer);
            Device.Indices = triBuffer;

            foreach (var pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                Device.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, triBuffer.IndexCount / 3);
            }
        }

        public static void DrawCube (Vector3 position, Quaternion rotation, Vector3 size, Color color)
        {
            var verts = new VertexPositionColor[24];
            var tris = new UInt16[36];

            var mat = Matrix.Create();
        }
    }
}
