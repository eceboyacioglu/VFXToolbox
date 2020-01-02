using UnityEngine;

namespace UnityEditor.VFXToolbox.ImageSequencer
{
    internal abstract class ProcessorBase : ScriptableObject
    {
        public abstract string shaderPath { get; }
        public abstract string processorName { get; }
        public virtual string label => processorName;

        protected FrameProcessor processor;

        public void AttachTo(FrameProcessor processor)
        {
            this.processor = processor;
        }

        public virtual int numU => 1;
        public virtual int numV => 1;
        public virtual int sequenceLength => processor.InputSequence.length;
        public abstract bool Process(int frame);
        public virtual void UpdateOutputSize()
        {
            processor.SetOutputSize(processor.InputSequence.width, processor.InputSequence.height);
        }
        public abstract bool OnInspectorGUI(bool changed, SerializedObject serializedObject);
        public abstract bool OnCanvasGUI(ImageSequencerCanvas canvas);
        public abstract void Default();
    }
}


